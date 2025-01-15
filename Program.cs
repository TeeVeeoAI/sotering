using System.ComponentModel.DataAnnotations;

void BubbleSort(ref int[] arr){

    bool swapped;
    for (int i = 0; i < arr.Length-1; i++){

        swapped = false;
        for (int j = 0; j < arr.Length-i-1; j++){

            if (arr[j] > arr[j+1]){
                int temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
                swapped = true;
            }

            if (!swapped){
                break;
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

void Main(){
    int[] ints = new int[100];
    for (int i = 0; i < ints.Length; i++){
        Random rnd = new Random();
        ints[i] = rnd.Next(1, 100);
    }
    SelectionSort(ref ints);

    foreach (int i in ints){
        Console.Write(i + ", ");
    }
}

Main();