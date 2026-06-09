using PPO_projekt.MAUI.ViewModels;

namespace PPO_projekt.MAUI.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _vm;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        _vm = vm;
        BindingContext = _vm;
    }

    private void OnAddStudentClicked(object sender, EventArgs e)
    {
        _vm.AddStudent();
    }

    private void OnAddGradeClicked(object sender, EventArgs e)
    {
        if (int.TryParse(_vm.GradeValue.ToString(), out _))
        {
            _vm.AddGrade();
        }
    }
}