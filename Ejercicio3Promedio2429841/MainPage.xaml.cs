namespace Ejercicio3Promedio2429841
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editPromedioId;
        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetPromedio());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

        }

        private async void PromedioBtn_Clicked(object sender, EventArgs e)
        {
            string Nombre = EntryNombreAlum.Text;
            string nota1 = EntryNota1.Text;
            string nota2 = EntryNota2.Text;
            string nota3 = EntryNota3.Text;
            string nota4 = EntryNota4.Text;
            string nota5 = EntryNota5.Text;

            if (!int.TryParse(nota1, out int Nota1) || !int.TryParse(nota2, out int Nota2) || !int.TryParse(nota3, out int Nota3) || !int.TryParse(nota4, out int Nota4) || !int.TryParse(nota5, out int Nota5))
            {
                await DisplayAlert ("Error", "Ingresa numeros enteros", "Aceotar");
                return;
            }

            int Promedio = (Nota1 + Nota2 + Nota3 + Nota4 + Nota5) /5 ;
            labelpromedio.Text = Nombre +  " Promedio Final " + Promedio.ToString();


            if (_editPromedioId == 0)
            {
                await _dbService.Create(new NotasProm
                {
                    Nombre = EntryNombreAlum.Text,
                    nota1 = EntryNota1.Text,
                    nota2 = EntryNota2.Text,
                    nota3 = EntryNota3.Text,
                    nota4 = EntryNota4.Text,
                    nota5 = EntryNota5.Text,
                    Promedio = labelpromedio.Text
                });
            }

            else
            {
                await _dbService.Update(new NotasProm
                {
                    Id = _editPromedioId,
                    Nombre = EntryNombreAlum.Text,
                    nota1 = EntryNota1.Text,
                    nota2 = EntryNota2.Text,
                    nota3 = EntryNota3.Text,
                    nota4 = EntryNota4.Text,
                    nota5 = EntryNota5.Text,
                    Promedio = labelpromedio.Text
                });

                _editPromedioId = 0;
            }

            EntryNombreAlum.Text = string.Empty;
            EntryNota1.Text = string.Empty;
            EntryNota2.Text = string.Empty;
            EntryNota3.Text = string.Empty;
            EntryNota4.Text = string.Empty;
            EntryNota5.Text = string.Empty;
            labelpromedio.Text = string.Empty;

            listview.ItemsSource = await _dbService.GetPromedio();
        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var notasProm = (NotasProm)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editPromedioId = notasProm.Id;
                    EntryNombreAlum.Text = notasProm.Nombre;
                    EntryNota1.Text = notasProm.nota1;
                    EntryNota2.Text = notasProm.nota2;
                    EntryNota3.Text = notasProm.nota3;
                    EntryNota4.Text = notasProm.nota4;
                    EntryNota5.Text = notasProm.nota5;
                    labelpromedio.Text = notasProm.Promedio;
                    break;

                case "Delete":
                    await _dbService.Delete(notasProm);
                    listview.ItemsSource = await _dbService.GetPromedio();
                    break;
            }
        }
    }

}
