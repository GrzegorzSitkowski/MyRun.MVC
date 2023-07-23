using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyRun.Application.Mappings;
using MyRun.Application.Race.Commands.CreateRace;
using MyRun.Application.Workout.Commands.CreateWorkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateRaceCommand));
            services.AddMediatR(typeof(CreateWorkoutCommand));

            services.AddAutoMapper(typeof(MyRunMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateRaceCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateWorkoutCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
