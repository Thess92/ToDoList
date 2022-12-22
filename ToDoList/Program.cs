using ToDoList;
using Task = ToDoList.Task;

MyDbContext Context = new MyDbContext();

bool On = true;

Console.WriteLine("Welcome to the ToDo List!");

// Calculates and displays the amount of tasks that are done or needs to be done.
List<Task> toDo = Context.Tasks.Where(x => x.IsDone == false).ToList();
List<Task> done = Context.Tasks.Where(x => x.IsDone == true).ToList();
Console.WriteLine($"You have {toDo.Count()} tasks to do and {done.Count()} tasks that are done.\n");

// Loop that runs until the variable "On" is changed to false.
while (On)
{
    // Menu.
    Console.WriteLine("(1) List All Tasks");
    Console.WriteLine("(2) Add New Task");
    Console.WriteLine("(3) Edit a Task");
    Console.WriteLine("(4) Delete a Task");
    Console.WriteLine("(5) Save and Quit");
    Console.WriteLine();
    Console.Write("Pick an option: ");
    string option = Console.ReadLine();
    Console.WriteLine("-------------------------");

    // Handles the user's input depending on their choice.
    switch (option)
    {
        // Displays all tasks.
        case "1":
            {
                List<Task> tasksList = Context.Tasks.ToList();

                Console.Write("Pick option 1 (Sort by due date) or 2 (Sort by project id): ");
                
                string input = Console.ReadLine();
                Console.WriteLine();

                // Handles if the user wants to sort by due date or project.
                switch (input)
                {
                    case "1":
                        {
                            List<Task> sortedByDueDate = tasksList.OrderBy(t => t.DueDate).ToList();

                            Console.WriteLine("All tasks (Done tasks are marked green.):\n");

                            Console.WriteLine("Title:".PadRight(15)
                                + "Due Date: ".PadRight(15)
                                + "Project Id:");

                            foreach (Task task in sortedByDueDate)
                            {
                                if (task.IsDone == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }

                                Console.WriteLine(task.Title.PadRight(15)
                                    + task.DueDate.ToString("d").PadRight(15)
                                    + task.ProjectId);

                                Console.ResetColor();
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        {
                            List<Task> sortedByProject = tasksList.OrderBy(t => t.ProjectId).ToList();

                            Console.WriteLine("All tasks (Done tasks are marked green.):\n");

                            Console.WriteLine("Title:".PadRight(15)
                                + "Due Date: ".PadRight(15)
                                + "Project Id:");

                            foreach (Task task in sortedByProject)
                            {
                                if (task.IsDone == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }

                                Console.WriteLine(task.Title.PadRight(15)
                                    + task.DueDate.ToString("d").PadRight(15)
                                    + task.ProjectId);

                                Console.ResetColor();
                            }
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Pick an option between 1 and 2, try again.\n");
                        break;
                }
            }
            break;
        // Adds new Task.
        case "2":
            {
                Task newTask = new Task();
                List<Project> projects = Context.Projects.ToList();

                Console.WriteLine("Add a new task with Title, Due Date and Project Id.");
                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Due Date (Format: YYYY-MM-DD): ");
                bool isDate = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);

                Console.WriteLine($"Project Id. Available Ids to choose from: ");
                foreach (var p in projects)
                {
                    Console.Write(p.Id + " ");
                }
                Console.Write("Pick one: ");
                bool isInt = Int32.TryParse(Console.ReadLine(), out int projectId);

                newTask.Title = title;
                newTask.DueDate = dueDate;
                newTask.IsDone = false;
                newTask.ProjectId = projectId;

                Context.Tasks.Add(newTask);
                Context.SaveChanges();
                Console.WriteLine("The task was saved.\n");
            }
            break;
        // Edits selected Task.
        case "3":
            {
                List<Task> tasksToEdit = Context.Tasks.ToList();
                List<Project> projects = Context.Projects.ToList();

                Console.WriteLine("All tasks (Done tasks are marked green.):\n");

                Console.WriteLine("Id:".PadRight(10)
                    + "Title:".PadRight(15)
                    + "Due Date: ".PadRight(15)
                    + "Project Id:");

                foreach (Task task in tasksToEdit)
                {
                    if (task.IsDone == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(task.Id.ToString().PadRight(10)
                        + task.Title.PadRight(15)
                        + task.DueDate.ToString("d").PadRight(15)
                        + task.ProjectId);

                    Console.ResetColor();
                }
                Console.WriteLine();

                Console.Write("Choose the Id of the Task you want to Edit: ");
                string editTask = Console.ReadLine();

                Task taskToEdit = Context.Tasks.FirstOrDefault(x => x.Id == Convert.ToInt32(editTask));

                Console.WriteLine("Edit the Title, Due Date, Status and Project Id of the Task.");
                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Due Date (Format: YYYY-MM-DD): ");
                bool isDate = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);

                Console.Write("Status (Write true if the Task is done or false if it is not): ");
                bool isBool = bool.TryParse(Console.ReadLine(), out bool isDone);

                Console.WriteLine($"Project Id. Available Ids to choose from: ");
                foreach (var p in projects)
                {
                    Console.Write(p.Id + " ");
                }
                Console.Write("Pick one: ");
                bool isInt = Int32.TryParse(Console.ReadLine(), out int projectId);

                taskToEdit.Title = title;
                taskToEdit.DueDate = dueDate;
                taskToEdit.IsDone = isDone;
                taskToEdit.ProjectId = projectId;

                Context.Tasks.Update(taskToEdit);
                Context.SaveChanges();
                Console.WriteLine("The task was saved.\n");
            }
            break;
        //Deletes selected task.
        case "4":
            List<Task> Tasks = Context.Tasks.ToList();

            Console.WriteLine("All tasks (Done tasks are marked green.):\n");

            Console.WriteLine("Id:".PadRight(10)
                + "Title:".PadRight(15)
                + "Due Date: ".PadRight(15)
                + "Project Id:");

            foreach (Task task in Tasks)
            {
                if (task.IsDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(task.Id.ToString().PadRight(10) 
                    + task.Title.PadRight(15)
                    + task.DueDate.ToString("d").PadRight(15)
                    + task.ProjectId);

                Console.ResetColor();
            }
            Console.WriteLine();

            Console.Write("Choose the Id of the Task you want to Delete: ");
            string deleteTask = Console.ReadLine();
            Task taskToDelete = Context.Tasks.FirstOrDefault(x => x.Id == Convert.ToInt32(deleteTask));
            Context.Tasks.Remove(taskToDelete);
            Context.SaveChanges();
            Console.WriteLine("The Task has been Deleted.\n");
            break;
        // Ends the loop to exit the application.
        case "5":
            {
                On = false;
                Console.WriteLine("See you later.");
            }
            break;
        default:
            Console.WriteLine("The number must be between 1 and 5, try again.\n");
            break;
    }
}