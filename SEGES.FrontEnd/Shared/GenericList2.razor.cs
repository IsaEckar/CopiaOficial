using Microsoft.AspNetCore.Components;

namespace SEGES.FrontEnd.Shared
{
    public partial class  GenericList2<Titem>
    {
        [Parameter] public RenderFragment? Loading { get; set; }//to show while loading
        [Parameter] public RenderFragment? NoRecords { get; set; }//tpo show when no records
        [Parameter, EditorRequired] public RenderFragment Body { get; set; } = null!;
        [Parameter, EditorRequired] public List<Titem> MyList { get; set; } = null!;
    }
}
