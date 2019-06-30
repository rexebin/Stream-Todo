﻿using System;
using System.Windows.Input;
using ReactiveUI;


namespace Todo
{
    public class TodoItemViewModel : ReactiveObject
    {
        public TodoItemViewModel(ITodoItem todo)
        {
            this.Item = todo;
        }


        public void MarkDirty()
        {
            this.RaisePropertyChanged(nameof(IsCompleted));
            this.RaisePropertyChanged(nameof(IsOverdue));
        }


        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }
        public ICommand MarkComplete { get; set; }
        public ITodoItem Item { get; }

        public string Title => this.Item.Title;
        public DateTime? DueDate => this.Item.DueDateUtc?.ToLocalTime();

        public bool IsCompleted => this.Item.CompletionDateUtc != null;
        public bool HasDueDate => this.Item.DueDateUtc != null;
        public bool IsOverdue => this.Item.DueDateUtc != null &&
                                 this.Item.CompletionDateUtc == null &&
                                 this.Item.DueDateUtc > DateTime.Now;
    }
}