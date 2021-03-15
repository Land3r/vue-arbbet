using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Enums
{
  /// <summary>
  /// UnifiedType Enum
  /// </summary>
  public enum UnifiedType
  {
    /// <summary>
    /// Master type. The entity has been unified, and this is the master node of the tree.
    /// </summary>
    Master,

    /// <summary>
    /// Platform type. The entity may have been unified or not, and is a leaf node of the tree.
    /// </summary>
    Platform
  }
}
