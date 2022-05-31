using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace PizzaPlace.Client.Pages
{
    public class InputWatcher : ComponentBase
    {
        private EditContext editcontext = default!;
        [CascadingParameter]
        public EditContext EditContext
        {
            get => this.editcontext;
            set
            {
                this.editcontext = value;
                EditContext.OnFieldChanged += async (sender, args) =>
                {
                    await FieldChanged.InvokeAsync(args.FieldIdentifier.FieldName);
                };
            }
        }

        [Parameter] 
        public EventCallback<string> FieldChanged { get; set; }
        public bool Validate() => EditContext?.Validate() ?? false;
    }
}
