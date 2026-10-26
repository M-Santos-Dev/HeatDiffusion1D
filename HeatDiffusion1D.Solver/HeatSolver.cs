namespace HeatDiffusion1D.Solver;

public class HeatSolver
{
    public static void Evolve(
        double[] T, 
        double[] TBuffer, 
        double alpha, 
        double dx, 
        double dt, 
        int timeSteps)
    {
        var n = T.Length;
        var r = alpha * dt / (dx * dx); // Fator de difusão (CFL)

        for (var step = 0; step < timeSteps; step++)
        {
            TBuffer[0] = T[0];
            TBuffer[n - 1] = T[n - 1];

            for (var i = 1; i < n - 1; i++)
            {
                TBuffer[i] = T[i] + r * (T[i + 1] - 2 * T[i] + T[i - 1]);
            }

            Array.Copy(TBuffer, T, n);
        }
    }
}