const apps = ["Management"];

const genTypes = ["Crud"];

const modules = ["Authentication", "Management", "System"];

const askCrudQuestions = async () => {
  const { default: inquirer } = await import("inquirer");

  const selectableTemplates = [
    "entity",
    "repository",
    "domainService",
    "applicationService",
    "controller",
    "request:create",
    "request:update",
    "request:delete",
    "request:getDetail",
    "request:getAll",
    "integrationTests",
  ];

  const answers = await inquirer.prompt([
    {
      type: "list",
      name: "app",
      message: "Select app",
      choices: apps,
      validate: (value) => {
        if (!value.length) {
          return "Please select app name";
        }
        return true;
      },
    },
    {
      type: "input",
      name: "entity",
      message: "Entity name",
      validate: (value) => {
        if (!value.length) {
          return "Please enter entity name";
        }

        const regex = /^[a-zA-Z]+$/;

        if (regex.test(value)) {
          return true;
        } else {
          return "Please enter a valid entity name(only letters)";
        }
      },
    },
    {
      type: "checkbox",
      name: "templates",
      message: "Select templates",
      choices: selectableTemplates,
      validate: (value) => {
        if (!value.length) {
          return "Please select at least one template";
        }

        return true;
      },
    },
  ]);

  return answers;
};

const askGenType = async () => {
  const { default: inquirer } = await import("inquirer");
  const answers = await inquirer.prompt([
    {
      type: "list",
      name: "genType",
      message: "Select gen type",
      choices: genTypes,
      validate: (value) => {
        if (!value.length) {
          return "Please enter gen type";
        }

        return true;
      },
    },
  ]);

  return answers;
};

const askModules = async () => {
  const { default: inquirer } = await import("inquirer");
  const module = await inquirer.prompt([
    {
      type: "list",
      name: "module",
      message: "Select Module",
      choices: modules,
      validate: (value) => {
        if (!value.length) {
          return "Please enter gen type";
        }

        return true;
      },
    },
  ]);

  return module;
};

module.exports = async (plugin) => {
  const { genType } = await askGenType();
  if (genType === "Crud") {
    const answers = await askCrudQuestions();
    let moduleName;
    // if (answers.app === 'Identity') {
    //     const { module } = await askIdentityModules();
    //     moduleName = module;
    // } else if (answers.app === 'Management') {
    const { module } = await askModules();
    moduleName = module;
    // } else if (answers.app === 'Booking') {
    //     const { module } = await askBookingModules();
    //     moduleName = module;
    // }
    // else {
    //     const { module } = await askPublisherModules();
    //     moduleName = module;
    // }
    console.log(moduleName);
    const entityCases = plugin.transformCases({
      source: answers.entity,
      cases: ["camel", "camelPlural", "pascal", "pascalPlural", "constant"],
      baseKey: "entity",
    });

    plugin.state = {
      ...entityCases,
      Module: moduleName,
      App: plugin.transformCase(answers.app, "pascal"),
      useEntity: answers.templates.includes("entity"),
      useRepository: answers.templates.includes("repository"),
      useDomainService: answers.templates.includes("domainService"),
      useApplicationService: answers.templates.includes("applicationService"),
      useController: answers.templates.includes("controller"),
      useCreateDtos: answers.templates.includes("request:create"),
      useUpdateDtos: answers.templates.includes("request:update"),
      useDeleteDtos: answers.templates.includes("request:delete"),
      useGetDetailDtos: answers.templates.includes("request:getDetail"),
      useGetAllDtos: answers.templates.includes("request:getAll"),
      useIntegrationTests: answers.templates.includes("integrationTests"),
    };

    plugin.templates = plugin.getTemplates(["./crud"]);
  }
};
