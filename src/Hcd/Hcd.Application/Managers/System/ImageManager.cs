using Hcd.Common.Interfaces.Abstractions;
using Hcd.Data.Entities.System;

namespace Hcd.Application.Managers.System;

public class ImageManager(IManagementRepository<Image> imageRepository) 
    : ManagementDomainService<Image>(imageRepository);