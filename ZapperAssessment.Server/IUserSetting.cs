using static ZapperAssessment.Server.UserSetting;

namespace ZapperAssessment.Server;

public interface IUserSetting
{
    List<string> GetUserSettings(string settingInput, Settings settingId);
}
