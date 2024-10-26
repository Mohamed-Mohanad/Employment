﻿namespace Employment.Application.Abstractions
{
    public interface ISeeder
    {
        public int ExecutionOrder { get; set; }
        Task SeedAsync();
    }
}
