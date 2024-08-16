
namespace PAMNotes
{
    public partial class MainPage : ContentPage
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "Notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(filePath))
            {
                NoteEditor.Text = File.ReadAllText(filePath);
            }
        }

        public void SaveButton_Clicked(object sender, EventArgs e)
        {
            string texto = NoteEditor.Text;
            TextLabel.Text = texto;
            File.WriteAllText(filePath, texto);
            DisplayAlert("Concluído", "Arquivo salvo com sucesso!", "Ok");
        }

        public void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                DisplayAlert("Concluído", "Arquivo apagado com sucesso!", "Ok");
                NoteEditor.Text = null;
            } 
            else
            {
                DisplayAlert("Aviso", "Arquivo não encontrado", "Ok");
            }
        }
    }
}