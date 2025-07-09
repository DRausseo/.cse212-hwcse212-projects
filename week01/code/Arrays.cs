public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Paso 1: Crear un arreglo de tamaño 'length' para guardar los múltiplos.
        // Paso 2: Usar un bucle for que se repita 'length' veces.
        // Paso 3: En cada iteración, calcular number * (i + 1) y guardar ese valor en el arreglo.
        // Paso 4: Devolver el arreglo al final.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 then the list after 
    /// the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Paso 1: Calcular desde dónde cortar la lista. Esto es data.Count - amount.
        // Paso 2: Usar GetRange para dividir la lista en dos partes:
        //         - tail: desde cutIndex hasta el final
        //         - head: desde el inicio hasta cutIndex
        // Paso 3: Limpiar la lista original usando Clear().
        // Paso 4: Agregar primero tail, luego head con AddRange().

        int cutIndex = data.Count - amount;

        List<int> tail = data.GetRange(cutIndex, amount);
        List<int> head = data.GetRange(0, cutIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
