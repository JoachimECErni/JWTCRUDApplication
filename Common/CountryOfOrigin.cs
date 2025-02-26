using System.Runtime.Serialization;

namespace CRUDApplication.Common
{
    public enum countryOfOrigin
    {
        [EnumMember(Value = "JP")]
        Japan,

        [EnumMember(Value = "US")]
        UnitedStates,

        [EnumMember(Value = "DE")]
        Germany,

        [EnumMember(Value = "GB")]
        UnitedKingdom,

        [EnumMember(Value = "CA")]
        Canada,

        [EnumMember(Value = "FR")]
        France,

        Unknown
    }

}
