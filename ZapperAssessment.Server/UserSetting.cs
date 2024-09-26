using static ZapperAssessment.Server.UserSetting;

namespace ZapperAssessment.Server;
public enum Settings
{
    SMSNotifEnabled = 1,
    PushNotifEnabled,
    BiometricsEnabled,
    CameraEnabled,
    LocationEnabled,
    NFCEnabeld,
    VouchersEnabled,
    LoyaltyEnabled
}

public class UserSetting : IUserSetting
{
    public List<string> GetUserSettings(string settingInput, Settings settingId)
    {
        List<string?> userSettings = new List<string?>();
        char[] inputArr = settingInput.ToCharArray();

        for (int i = 0; i < inputArr.Length; i++)
        {
            if ((inputArr[i] - '0' == 1) && (int)settingId == i + 1)
            {
                if (Enum.IsDefined(typeof(Settings), settingId))
                {
                    userSettings.Add(Enum.GetName(typeof(Settings), settingId));
                }
            }
        }

        return userSettings!;
    }
}
