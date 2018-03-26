using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class MainView : View
    {
        private StudentsController controller;
        private ConsoleMenu menu = new ConsoleMenu();

        public MainView(StudentsController controller)
        {
            this.controller = controller;

            menu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Add new student", ActionToExecute = new MenuItemAction(AddNewStudent) });
            menu.AddItem(new MenuItem { ShortcutChar = '2', Text = "Display all students", ActionToExecute = new MenuItemAction(DisplayStudents) });
            menu.AddItem(new MenuItem { ShortcutChar = '3', Text = "Delete existing student", ActionToExecute = new MenuItemAction(DeleteStudent) });
            menu.AddItem(new MenuItem { ShortcutChar = '4', Text = "Modify existing student", ActionToExecute = new MenuItemAction(ModifyStudent) });
        }

        public override View Execute()
        {
            menu.Run();
            return null;
        }

        private void AddNewStudent(object sender, object contextObject)
        {
            View addView = controller.GetAddStudentView();
            addView.Execute();
        }

        private void DisplayStudents(object sender, object contextObject)
        {
            View listView = controller.GetListStudentView();
            listView.Execute();
        }

        private void DeleteStudent(object sender, object contextObject)
        {
            View deleteView = controller.GetDeleteStudentView();
            deleteView.Execute();
        }

        private void ModifyStudent(object sender, object contextObject)
        {
            View modifyView = controller.GetModifyStudentView();
            modifyView.Execute();
        }
    }
}
