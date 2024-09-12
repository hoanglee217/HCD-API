#!/bin/node

const { execSync } = require('child_process');

const { getRunnableProjects } = require('./dotnetUtils');

const askQuestions = async () => {
    const { default: inquirer } = await import('inquirer');


    return await inquirer.prompt([
        {
            name: "project",
            type: "list",
            choices: getRunnableProjects(),
            message: "Which projects do you want to run?",
            validate: function (answer) {
                if (answer.length < 1) {
                    return 'You must choose at least one project.';
                }

                return true;
            }
        }
    ]);
};

askQuestions()
    .then(async answers => {
        const {
            project
        } = answers;

        const command = `dotnet run --project ${project}`;
        console.log(command);
        execSync(command, { stdio: 'inherit' });
    });