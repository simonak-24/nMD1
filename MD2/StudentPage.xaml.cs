using MD2.StudentVM;

namespace MD2;

public partial class StudentPage : ContentPage
{
    private IStudentViewModel _vm;
    public StudentPage(IStudentViewModel vm)
	{
        _vm = vm;
        this.BindingContext = _vm;
        InitializeComponent();
	}
}