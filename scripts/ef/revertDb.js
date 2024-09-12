const { execSync } = require('child_process');

const askQuestions = async () => {
    const { default: inquirer } = await import('inquirer');

    return await inquirer.prompt([
        {
            name: 'toMigration',
            type: 'input',
            message: 'Migration to revert to?'
        }
    ]);
};

module.exports = async (projectName) => {
    const answers = await askQuestions()

    const { toMigration } = answers;

    const command = `dotnet ef database update ${toMigration} --project ${projectName} --startup-project ${projectName}`;
    
    console.log(command);

    execSync(command, { stdio: 'inherit' });
}