using Microsoft.AspNetCore.Mvc;

namespace ZapperAssessment.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSettingController : ControllerBase
    {
        private readonly ILogger<UserSettingController> _logger;
        private IUserSetting _userSetting;
        private LogReader _reader;

        public UserSettingController(ILogger<UserSettingController> logger,
            IUserSetting userSetting,
            LogReader reader)
        {
            _logger = logger;
            _userSetting = userSetting;
            _reader = reader;
        }

        [HttpGet("GetUserSettingConfirmation")]
        public IActionResult IsUserSettingValid([FromQuery] string settingInput, [FromQuery] Settings settingId)
        {
            var userSettings = _userSetting.GetUserSettings(settingInput, settingId);

            if (userSettings.Count == 0)
            {
                _logger.LogWarning($"Invalid user setting(s) input: settings [{settingInput}], setting [{(int)settingId}]");
                return Ok(false);
            }

            _logger.LogInformation($"Valid user setting(s) ({string.Join(", ", userSettings)}):" +
                $"settings [{settingInput}], setting [{(int)settingId}]");

            return Ok(true);
        }

        [HttpGet("GetValidUserSettingsFromLogs")]
        public IActionResult GetValidUserSettingsFromLogs()
        {
            return Ok(_reader.GetValidUserSettingsLogs());
        }
    }
}
