using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

void BubbleSort(ref int[] arr){
    for (int i = 0; i < arr.Length-1; i++){

        for (int j = 0; j < arr.Length-i-1; j++){

            if (arr[j] > arr[j+1]){
                int temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
            }
        }
    }
}

void SelectionSort(ref int[] arr){

    for (int i = 0; i < arr.Length-1; i++){

        int min = i;
        for (int j = i+1; j < arr.Length; j++){

            if (arr[j] < arr[min]){

                min = j;
            }
        }
        int temp = arr[i];
        arr[i] = arr[min];
        arr[min] = temp;
    }
}

void Merge(ref int[] arr, int p, int m, int r){
    int[] b = new int[arr.Length];

    int i = p;
    int k = 0;
    int j = m+1;

    while (i <= m && j <= r){
        if (arr[i] < arr[j]) {
            b[k++] = arr[i++];
        }
        else {
            b[k++] = arr[j++];  
        }
    }

    while (i <= m){
        b[k++] = arr[i++];
    }

    while (j <= r){
        b[k++] = arr[j++];
    }

    for (i = r; i >= p; i--)
    {
        arr[i] = b[--k];
    }
}

void MergSort(ref int[] arr, int p, int r){
    if (arr[0] < arr[arr.Length-1]){
        int m = (p + r) / 2;

        MergSort(ref arr, p, m);

    }
}

void Main(){
    Stopwatch watch = new Stopwatch();
    int[] ints = new int[10000];
    for (int i = 0; i < ints.Length; i++){
        Random rnd = new Random();
        ints[i] = rnd.Next(1, 1000000);
    }

    watch.Start();
    BubbleSort(ref ints);
    watch.Stop();

    foreach (int i in ints){
        Console.Write(i + ", ");
    }
    TimeSpan ts = watch.Elapsed;
    Console.WriteLine("\n\n"+ts);
}

Main();