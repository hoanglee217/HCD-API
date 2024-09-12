exports.getMigratorProject = async () => {
    return [
        './src/Hcd.Identity/Hcd.Identity.Migrator',
        './src/Hcd.Management/Hcd.Management.Migrator',
    ];
};