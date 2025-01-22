
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

void Merge(int[] arr, int l, int m, int r)
{
    int n1 = m - l + 1;
    int n2 = r - m;

    int[] L = new int[n1];
    int[] R = new int[n2];
    int i, j;

    for (i = 0; i < n1; ++i)
        L[i] = arr[l + i];
    for (j = 0; j < n2; ++j)
        R[j] = arr[m + 1 + j];

    i = 0;
    j = 0;

    int k = l;
    while (i < n1 && j < n2) {
        if (L[i] <= R[j]) {
            arr[k] = L[i];
            i++;
        }
        else {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    while (i < n1) {
        arr[k] = L[i];
        i++;
        k++;
    }


    while (j < n2) {
        arr[k] = R[j];
        j++;
        k++;
    }
}


void MergeSort(int[] arr, int l, int r)
{
    if (l < r) {

        int m = l + (r - l) / 2;

        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);

        Merge(arr, l, m, r);
    }
}

int Partition(int[] arr, int low, int high){
    int pivot = arr[high];
    int i = low-1;

    for (int j = low; j <= high; j++){
        if (arr[j] < pivot) {
            i++;
            Swap(arr, i, j);
        }
    }

    Swap(arr, i+1, high);
    return i + 1;
}

void Swap(int[] arr, int i, int j){
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

void QuickSort(int[] arr, int low, int high){
    if (low < high) {

        int pi = Partition(arr, low, high);

        QuickSort(arr, low, pi-1);
        QuickSort(arr, pi+1, high);
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
    QuickSort(ints, 0, ints.Length-1);
    watch.Stop();

    foreach (int i in ints){
        Console.Write(i + ", ");
    }
    TimeSpan ts = watch.Elapsed;
    Console.WriteLine("\n\n"+ts);
}

Main();