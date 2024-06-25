﻿namespace Ayerhs.Core.Interfaces.Utility
{
    /// <summary>
    /// Interface for Email Service functionalities.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email containing a One-Time Password (OTP) to the specified recipient.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="otp">The One-Time Password to include in the email body.</param>
        /// <param name="subject">The custom email subject.</param>
        /// <param name="body">The custom body content of the email. If not provided, a default message with the OTP code will be used.</param>
        /// <param name="isHtml">HTML email body</param>
        /// <returns>An asynchronous task representing the email sending operation.</returns>
        Task SendOtpEmailAsync(string email, string otp, string subject, string body, bool isHtml = false);
    }
}
