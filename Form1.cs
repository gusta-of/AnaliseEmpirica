using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AnaliseEmpirica
{
    public partial class Form1 : Form
    {
        private Stopwatch _cronometro;
        ExecuteAnalize Analise = new ExecuteAnalize();
        BackgroundWorker _bs = new BackgroundWorker();
        int[] dez3;
        int[] dez4;
        int[] dez5;
        private int _tamanho3;
        private int _tamanho5;
        private int _tamanho4;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        public Form1()
        {
            InitializeComponent();
            ExecuteInsertionsort();

        }

        private void ExecuteInsertionsort()
        {
            _tamanho3 = Convert.ToInt32(Math.Pow(Convert.ToDouble(10), Convert.ToDouble(3)));
            _tamanho4 = Convert.ToInt32(Math.Pow(Convert.ToDouble(10), Convert.ToDouble(4)));
            _tamanho5 = Convert.ToInt32(Math.Pow(Convert.ToDouble(10), Convert.ToDouble(5)));
        }

        private void ExecuteCrescente()
        {
            dez3 = new int[_tamanho3];
            dez4 = new int[_tamanho4];
            dez5 = new int[_tamanho5];

            //Executa Analise vetor Crescente
            UtilidadeCarregaVetor.GerarVetorCrescente(_tamanho3, dez3);
            UtilidadeCarregaVetor.GerarVetorCrescente(_tamanho4, dez4);
            UtilidadeCarregaVetor.GerarVetorCrescente(_tamanho5, dez5);
        }

        private void ExecuteDecrescente()
        {
            dez3 = new int[_tamanho3];
            dez4 = new int[_tamanho4];
            dez5 = new int[_tamanho5];

            //Executa Analise vetor Decrescente 
            UtilidadeCarregaVetor.GerarVetorDecrescente(_tamanho3, dez3);
            UtilidadeCarregaVetor.GerarVetorDecrescente(_tamanho4, dez4);
            UtilidadeCarregaVetor.GerarVetorDecrescente(_tamanho5, dez5);
        }

        private void ExecuteRandomico()
        {
            dez3 = new int[_tamanho3];
            dez4 = new int[_tamanho4];
            dez5 = new int[_tamanho5];

            //Executa Analise vetor Randomico
            UtilidadeCarregaVetor.GerarVetorRandomico(_tamanho3, dez3);
            UtilidadeCarregaVetor.GerarVetorRandomico(_tamanho4, dez4);
            UtilidadeCarregaVetor.GerarVetorRandomico(_tamanho5, dez5);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            ExecuteInsertionSorte();
            ExecuteSelectionSort();
            ExecuteBubleSort();
            ExecuteMergeSort();
            ExecuteQuick();
            ExecuteShell();

            lblTempo.Text = $"Tempo para execução: {_cronometro.Elapsed.ToString()}";

            var texto = listBox.Text;
        }

        private void AnaliseAlgoritmo(string metodo, object[] parametros, string tipoVetor, long tamanho)
        {
            Acao($"Metodo executado: {metodo} - vetor {tipoVetor} - tamanho : {tamanho}");
            _cronometro = new Stopwatch();
            _cronometro.Start();
            Analise.AcaoLog(menssagem => Acao(menssagem));
            Execute(Analise, metodo, parametros);
            _cronometro.Stop();
            Acao($"Tempo de Execução: {_cronometro.Elapsed.ToString()}");
            Acao($"\n\n");
        }

        private void Acao(string mensagem)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { Acao(mensagem); });


            using (StreamWriter writer = new StreamWriter(@"C:\Users\PC-01\Desktop\AULAS 2019-2\Estruturall\AnaliseEmpirica\arquivo.txt", true))
            {
                writer.WriteLine(mensagem);
            }

            listBox.Items.Add(mensagem);
            listBox.SelectedIndex = listBox.Items.Count - 1;
        }

        public void Execute(object classe, string nomeDoMetodo, params object[] parametros)
        {
            Execute(() =>
            {
                var type = classe.GetType();
                return type.InvokeMember(nomeDoMetodo, BindingFlags.InvokeMethod, null, classe, parametros) as byte[];
            });
        }

        public void Execute(Func<byte[]> acaoExecucao)
        {
            acaoExecucao.Invoke();
        }

        private void ExecuteInsertionSorte()
        {
            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez3 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez4 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez5 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez3 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez4 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez5 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez3 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez4 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.Insertionsort), new object[] { dez5 }, "Decrescente", _tamanho5);
        }

        private void ExecuteSelectionSort()
        {
            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez3 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez4 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez5 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez3 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez4 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez5 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez3 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez4 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.SelectionSort), new object[] { dez5 }, "Decrescente", _tamanho5);
        }

        private void ExecuteBubleSort()
        {
            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez3 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez4 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez5 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez3 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez4 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez5 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez3 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez4 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.BubleSort), new object[] { dez5 }, "Decrescente", _tamanho5);
        }

        private void ExecuteMergeSort()
        {

            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez3, new int[_tamanho3], 0, _tamanho3 - 1 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez4, new int[_tamanho4], 0, _tamanho4 - 1 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez5, new int[_tamanho5], 0, _tamanho5 - 1 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez3, new int[_tamanho3], 0, _tamanho3 - 1 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez4, new int[_tamanho4], 0, _tamanho4 - 1 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez5, new int[_tamanho5], 0, _tamanho5 - 1 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez3, new int[_tamanho3], 0, _tamanho3 - 1 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez4, new int[_tamanho4], 0, _tamanho4 - 1 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.MergeSort), new object[] { dez5, new int[_tamanho5], 0, _tamanho5 - 1 }, "Decrescente", _tamanho5);
        }

        private void ExecuteQuick()
        {

            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez3, 0, _tamanho3 - 1 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez4, 0, _tamanho4 - 1 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez5, 0, _tamanho5 - 1 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez3, 0, _tamanho3 - 1 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez4, 0, _tamanho4 - 1 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez5, 0, _tamanho5 - 1 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez3, 0, _tamanho3 - 1 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez4, 0, _tamanho4 - 1 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.QuickSort), new object[] { dez5, 0, _tamanho5 - 1 }, "Decrescente", _tamanho5);
        }

        private void ExecuteShell()
        {
            ExecuteRandomico();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez3 }, "Randomico", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez4 }, "Randomico", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez5 }, "Randomico", _tamanho5);

            ExecuteCrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez3 }, "Crescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez4 }, "Crescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez5 }, "Crescente", _tamanho5);

            ExecuteDecrescente();
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez3 }, "Decrescente", _tamanho3);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez4 }, "Decrescente", _tamanho4);
            AnaliseAlgoritmo(nameof(ExecuteAnalize.ShellSort), new object[] { dez5 }, "Decrescente", _tamanho5);
        }
    }
}
