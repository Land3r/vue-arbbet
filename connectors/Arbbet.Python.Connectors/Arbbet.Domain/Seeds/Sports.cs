using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;

namespace Arbbet.Domain.Seeds
{
    public class Sports
    {
        public static IList<Sport> Data = new List<Sport>()
        {
            #region MASTER
            new Sport()
            {
                Id = Guid.Parse("685792bf-ed12-4b16-b54b-d7a6c08c0d74"),
                Name = "Football",
                Code = "FOO",
                PlatformId = null,
                Platform_Id = null,
                UnifiedEntityId = null,
                UnifiedType = UnifiedType.Master
            },
            #endregion MASTER
            #region FDJ
            new Sport()
            {
                Id = Guid.Parse("0405459e-dff5-4e98-9f18-cde23fe456ae"),
                Name = "Football",
                Code = "FOO",
                PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
                Platform_Id = "100",
                UnifiedEntityId = Guid.Parse("685792bf-ed12-4b16-b54b-d7a6c08c0d74"),
                UnifiedType = UnifiedType.Platform
            },
            //new Sport()
            //{
            //  Id = Guid.Parse("a588cc21-4797-4916-95ec-fc54e7bacd44"),
            //  Name = "Tennis",
            //  Code = "TEN",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "600",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("4c855310-ec82-48dd-9ba5-9bd611804d4e"),
            //  Name = "Basketball",
            //  Code = "BAS",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "601600",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("6dc779c4-113f-4aa5-855a-65959b0426cf"),
            //  Name = "Rugby",
            //  Code = "RUG",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "964500",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("b3082cf0-1ce3-4ee0-8a2a-105055f3d851"),
            //  Name = "Volley",
            //  Code = "VOL",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "1200",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("43730787-c53e-49a1-80a2-4db01d95d38a"),
            //  Name = "Handball",
            //  Code = "HAN",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "1100",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("ca33fb07-fd55-4c25-8ef9-7a62e75be407"),
            //  Name = "Hockey",
            //  Code = "HOC",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "2100",
            //  UnifiedType = UnifiedType.Platform
            //},
            //new Sport()
            //{
            //  Id = Guid.Parse("3478ac3e-b02b-46ab-9db4-716519476f73"),
            //  Name = "Boxe",
            //  Code = "BOX",
            //  PlatformId = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
            //  Platform_Id = "364800",
            //  UnifiedType = UnifiedType.Platform
            //}
            #endregion FDJ
            #region UNI
            new Sport()
            {
                Id = Guid.Parse("f9a054a5-99f5-47b0-967e-9e8ac005a147"),
                Name = "Football",
                Code = "FOO",
                PlatformId = Guid.Parse("238d312e-d0b0-4108-9993-2cd322359f76"),
                Platform_Id = null,
                UnifiedEntityId = Guid.Parse("685792bf-ed12-4b16-b54b-d7a6c08c0d74"),
                UnifiedType = UnifiedType.Platform
            }
            #endregion UNI
        };
    }
}
