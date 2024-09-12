#!/bin/node

const { execSync } = require("child_process");

const { getMigratorProject } = require("./migrationUtils");
const addMigration = require("./addMigration");
const revertDb = require("./revertDb");

const askQuestions = async () => {
  const { default: inquirer } = await import("inquirer");

  const migrationActions = [
    { name: " Add", value: "Add" },
    { name: " Remove", value: "Remove" },
    { name: " List", value: "List" },
  ];

  const databaseActions = [
    { name: " Update", value: "Update Database" },
    { name: " Revert", value: "Revert Database" },
    { name: " Init", value: "Seed Database" },
  ];

  return await inquirer.prompt([
    {
      name: "projectName",
      type: "list",
      choices: await getMigratorProject(),
      message: "Which project do you want to run the migration for?",
    },
    {
      name: "action",
      type: "list",
      message: "What do you want to do?",
      choices: [
        new inquirer.Separator("Migrations:"),
        ...migrationActions,
        new inquirer.Separator("Database:"),
        ...databaseActions,
      ],
    },
  ]);
};

askQuestions().then(async (answers) => {
  const { action, projectName } = answers;

  if (action === "Add") {
    await addMigration(projectName);
  }

  if (action === "Remove") {
    const command = `dotnet ef migrations remove --project ${projectName} --startup-project ${projectName} `;
    execSync(command, { stdio: "inherit" });
  }

  if (action === "List") {
    const command = `dotnet ef migrations list --project ${projectName} --startup-project ${projectName}`;
    execSync(command, { stdio: "inherit" });
  }

  if (action === "Update Database") {
    const command = `dotnet ef database update --project ${projectName} --startup-project ${projectName} `;
    execSync(command, { stdio: "inherit" });
  }

  if (action === "Revert Database") {
    await revertDb(projectName);
  }

  if (action === "Seed Database") {
    const command = `dotnet run --project ${projectName} `;
    execSync(command, { stdio: "inherit" });
  }
});
