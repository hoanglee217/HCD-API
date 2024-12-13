using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hcd.Common.Interfaces.Abstractions.Auditing;

public interface IAuditedObject : ICreationAuditedObject, IModificationAuditedObject

{

}
