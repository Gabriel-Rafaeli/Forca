namespace Forca.FormsApp
{
    public partial class Form1 : Form
    {
        Forca forca;

        public Form1()
        {
            forca = new Forca();
            InitializeComponent();
            ConfigurarBotoes();
            lblPalavra.Text = forca.palavraCriptografada;
        }

        int numErros = 0;
        private void ConfigurarBotoes()
        {
            foreach (Control controle in panelLetras.Controls)
            {
                if (controle is Button)
                {
                    ((Button)controle).Click += AtribuirLetra;
                }
            }
        }

        private void AtribuirLetra(object sender, EventArgs e)
        {
            lblPalavra.Text = forca.palavraCriptografada;

            Button botaoClicado = (Button)sender;
            char letra = botaoClicado.Text.ToUpper()[0];

            if (forca.LetrasEscolhidas.Contains(letra))
            {
                MessageBox.Show("Você já escolheu essa letra antes!");
                return;
            }

            forca.LetrasEscolhidas.Add(letra);

            if (forca.palavraRandom.Contains(letra))
            {
                for (int i = 0; i < forca.palavraRandom.Length; i++)
                {
                    if (forca.palavraRandom[i] == letra)
                    {
                        forca.palavraCriptografada = forca.palavraCriptografada.Substring(0, i) + letra + forca.palavraCriptografada.Substring(i + 1);
                    }
                }

                lblPalavra.Text = forca.palavraCriptografada;

                botaoClicado.BackColor = Color.SpringGreen;

                if (forca.palavraCriptografada == forca.palavraRandom)
                {
                    MessageBox.Show("Parabéns, você acertou a palavra!");
                }
            }
            else
            {
                botaoClicado.BackColor = Color.LightCoral;

                numErros++;

                switch (numErros)
                {
                    case 1:
                        imgCabeca.Visible = true;
                        break;
                    case 2:
                        imgCorpo.Visible = true;
                        break;
                    case 3:
                        imgBracoD.Visible = true;
                        break;
                    case 4:
                        imgBracoE.Visible = true;
                        break;
                    case 5:
                        imgPernaD.Visible = true;
                        break;

                    case 6:
                        imgPernaE.Visible = true;
                        MessageBox.Show("Que pena, você perdeu! A palavra era " + forca.palavraRandom);
                        break;
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            forca.GerarPalavra();
            forca.LetrasEscolhidas.Clear();
            lblPalavra.Text = forca.palavraCriptografada;

            foreach (Control controle in panelLetras.Controls)
            {
                if (controle is Button)
                {
                    ((Button)controle).BackColor = Color.Black;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    pictureBox.Visible = false;
                }
            }
            imgForca.Visible = true;
            numErros = 0;

        }
    }
}