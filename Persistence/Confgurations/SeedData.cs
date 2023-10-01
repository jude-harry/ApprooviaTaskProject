using Domain.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Confgurations
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var itemRepository = services.GetRequiredService<IAsyncRepository<TaskProject>>();
                var saveChanges = serviceProvider.GetRequiredService<IUnitOfWork>();

                if (!itemRepository.GetAll().Result.Any())
                {
                    itemRepository.Add(new TaskProject {
                        Id = 1,
                        TaskName = "Item 1",
                        TaskDescription = "this is item 1",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 2,
                        TaskName = "Item 2",
                        TaskDescription = "this is item 2",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 3,
                        TaskName = "Item 3",
                        TaskDescription = "this is item 3",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 4,
                        TaskName = "Item 4",
                        TaskDescription = "this is item 4",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = false,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 5,
                        TaskName = "Item 5",
                        TaskDescription = "this is item 5",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 6,
                        TaskName = "Item 6",
                        TaskDescription = "this is item 6",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 7,
                        TaskName = "Item 7",
                        TaskDescription = "this is item 7",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    itemRepository.Add(new TaskProject
                    {
                        Id = 8,
                        TaskName = "Item 8",
                        TaskDescription = "this is item 8",
                        StartDate = DateTime.Now,
                        AllottedTime = 1,
                        ElapsedTime = 1,
                        TaskStatus = true,
                        EndDate = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(2),
                        DaysOverdue = 2,
                        DaysLate = 2

                    });
                    saveChanges.CommitChangesAsync();
                }

            }
            catch (Exception ex)
            {

            }
         }
    }

}
