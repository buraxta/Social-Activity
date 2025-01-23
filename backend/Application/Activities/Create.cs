using System;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class Create
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class Handler(DataContext context, ILogger<Handler> logger) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation(
                    "Attempting to create a new activity with ID: {ActivityId}",
                    request.Activity.Id
                );

                // Add the new activity to the database
                context.Activities.Add(request.Activity);
                await context.SaveChangesAsync();

                logger.LogInformation(
                    "Activity with ID: {ActivityId} created successfully.",
                    request.Activity.Id
                );
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while creating activity with ID: {ActivityId}",
                    request.Activity.Id
                );
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
    }
}
