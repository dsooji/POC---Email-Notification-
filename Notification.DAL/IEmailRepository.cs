﻿using Notification.Entities.Models;

namespace Notification.DAL
{
    public interface IEmailRepository
    {
        Task<bool> SaveEmail(MailRequest mailRequest);

    }
}