﻿using Employment.Application.Abstractions.Messaging;
using Employment.Domain.Enums;

namespace Employment.Application.Features.VacancyManagement.Commands.CreateVacancy
{
    public class CreateVacancyCommand : ICommand
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int MaxApplications { get; set; }
        public DateTime ExpiryDate { get; set; }
        public VacancyStatus Status { get; set; }
    }
}