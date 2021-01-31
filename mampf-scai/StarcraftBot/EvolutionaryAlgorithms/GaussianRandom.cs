using System;

namespace StarcraftBot.EvolutionaryAlgorithms
{
    /// <summary>
    /// Borrowed from from: http://imusthaveit.spaces.live.com/blog/cns!B5212D3C9F7D8093!398.entry
    /// </summary>
    class GaussianRandom : Random
    {
        /// <summary>
        /// http://imusthaveit.spaces.live.com/blog/cns!B5212D3C9F7D8093!398.entry
        /// Choose the next random number. The distribution of randomness is "normal"
        /// or "Gaussian" with a mean value dMu and a standard deviation of dSigma
        /// 
        /// The Gaussian distribution (sometimes called the "Normal distribution") has a distinctive "bell curve" shape 
        /// with a clear peak of values clustered around a center point (the mean), with the frequency of surrounding values 
        /// trailing off to either side of the peak. The width of the peak (how spread out it is) is controlled by a second number,
        /// the "standard deviation" usually denoted by the lower-case greek symbol, sigma.
        /// </summary>
        /// <param name="dMu">The center point (mean) of the normal distribution</param>
        /// <param name="dSigma">The standard deviation of the distribution</param>
        /// <returns>Random value</returns>
        public double NextGaussian(double dMu, double dSigma)
        {
            return dMu + CumulativeGaussian(base.NextDouble()) * dSigma;
        }

        private static double CumulativeGaussian(double p)
        {
            // p is a rectangular probability between 0 and 1
            // convert that into a gaussian.
            // Apply the inverse cumulative gaussian distribution function
            // This is an approximation by Abramowitz and Stegun; Press, et al.
            // See http://www.pitt.edu/~wpilib/statfaq/gaussfaq.html
            // Because of the symmetry of the normal
            // distribution, we need only consider 0 < p < 0.5. If you have p > 0.5,
            // then apply the algorithm below to q = 1-p, and then negate the value
            // for X obtained.
            bool fNegate = false;

            if (p > 0.5)
            {
                p = 1.0 - p;
                fNegate = true;
            }

            double t = Math.Sqrt(Math.Log(1.0 / (p * p)));
            double tt = t * t;
            double ttt = tt * t;
            double X = t - ((c_0 + c_1 * t + c_2 * tt) / (1 + d_1 * t + d_2 * tt + d_3 * ttt));

            return fNegate ? -X : X;
        }

        private const double c_0 = 2.515517;
        private const double c_1 = 0.802853;
        private const double c_2 = 0.010328;
        private const double d_1 = 1.432788;
        private const double d_2 = 0.189269;
        private const double d_3 = 0.001308;
    }
}