using System;

namespace AnaliseEmpirica
{
    public class ExecuteAnalize
    {
        private Action<string> _acaoLog;
        int _troca = 0;
        public ExecuteAnalize()
        {
        }

        public void AcaoLog(Action<string> acaoLog)
        {
            _acaoLog = acaoLog;
        }

        public void Insertionsort(int[] array)
        {
            int aux, j = 0;
            long troca = 0;
            for (int i = 1; i < array.Length; i++)
            {
                j = i - 1;
                aux = array[i];
                while (j > 0 && array[j] > aux)
                {
                    array[j + 1] = array[j];
                    j--;
                    troca++;
                }
                array[j + 1] = aux;
            }

            _acaoLog($"Quantidade de trocas: {troca}");
        }



        public void SelectionSort(int[] array)
        {
            int j = 0;
            int aux = 0;
            int posMenor = 0;
            long troca = 0;
            for (int i = 0; i <= array.Length; i++)
            {
                posMenor = i;
                for (j = i + 1; j <= array.Length; j++)
                {
                    if (j < array.Length)
                    {
                        if (array[j] < array[posMenor])
                        {
                            posMenor = j;
                        }
                    }
                }

                if (i < array.Length)
                {
                    aux = array[posMenor];
                    array[posMenor] = array[i];
                    array[i] = aux;
                    troca++;
                }
            }

            _acaoLog($"Quantidade de trocas: {troca}");
        }

        public void BubleSort(int[] array)
        {
            int aux = 0;
            long troca = 0;
            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        aux = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = aux;
                        troca++;
                    }
                }
            }

            _acaoLog($"Quantidade de trocas: {troca}");
        }

        public void MergeSort(int[] array, int[] arrayAux, int inicio, int fim)
        {
            int meio = 0;
            if (inicio < fim)
            {
                meio = (inicio + fim) / 2;
                MergeSort(array, arrayAux, inicio, meio);
                MergeSort(array, arrayAux, meio + 1, fim);
                Intercalar(array, arrayAux, inicio, meio, fim);
            }

        }

        private void Intercalar(int[] array, int[] arrayAux, int inicio, int meio, int fim)
        {
            int i, j, k;

            for (k = inicio; k <= fim; k++)
            {
                arrayAux[k] = array[k];
            }

            i = inicio;
            j = meio + 1;

            for (k = inicio; k <= fim; k++)
            {
                if (i > meio)
                {
                    arrayAux[k] = array[j++];
                }
                else if (j > fim)
                {
                    arrayAux[k] = array[i++];
                }
                else if (array[i] < array[j])
                {
                    arrayAux[k] = array[i++];
                }
                else
                {
                    arrayAux[k] = array[i++];
                    _troca++;
                }


            }

            if (inicio == 0 && fim == array.Length - 1)
                _acaoLog($"Quantidade de trocas: {_troca}");

        }

        public void QuickSort(int[] vet, int inicio, int fim)
        {

            int i = inicio;
            int j = fim;
            int pivo = vet[(inicio + fim) / 2];

            while (i <= j)
            {
                if (vet[i] < pivo) i++;
                else if (vet[j] > pivo) j--;
                else if (i <= j)
                {
                    trocar(vet, i, j);
                    i++;
                    j--;
                }
            }

            if (inicio < j) QuickSort(vet, inicio, j);

            if (i < fim) QuickSort(vet, i, fim);

            if (i == pivo)
                _acaoLog($"Quantidade de trocas: {_troca}");
        }

        private void trocar(int[] v, int i, int j)
        {
            int aux = v[i];
            v[i] = v[j];
            v[j] = aux;
            _troca++;
        }

        public void ShellSort(int[] vet)
        {
            int troca = 0;
            int h;
            int j;
            int valor;
            h = (vet.Length) / 2;
            while (h > 0)
            {
                for (int i = h; i < vet.Length; i++)
                {
                    valor = vet[i];
                    j = i;
                    while (j >= h && vet[j - h] > valor)
                    {
                        vet[j] = vet[j - h];
                        j = j - h;
                        troca++;
                    }
                    vet[j] = valor;
                    troca++;
                }
                h = h / 2;
            }

            _acaoLog($"Quantidade de trocas: {troca}");
        }
    }
}
