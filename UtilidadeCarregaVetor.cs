using System;

namespace AnaliseEmpirica
{
    public static class UtilidadeCarregaVetor
    {

        public static int[] GerarVetorRandomico(long tamanho, int[] vet)
        {
            Random rand = new Random();
            for (int i = 0; i < tamanho; i++)
            {
                vet[i] = rand.Next(0, Convert.ToInt32(tamanho));
            }

            return vet;
        }

        public static int[] GerarVetorCrescente(long tamanho, int[] vet)
        {
           for(int i = 0; i < tamanho; i++)
            {
                vet[i] = i;
            }

            return vet;
        }

        public static int[] GerarVetorDecrescente(long tamanho, int[] vet)
        {
            int valor = 0;
            for (var i = tamanho -1; i >= 0; i--)
            {
                vet[i] = valor;
                valor++;
            }

            return vet;
        }

    }
}
