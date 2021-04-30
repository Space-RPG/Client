using UnityEngine;

namespace SpaceGame.Celestial
{
    public class SimpleNoiseFilter : INoiseFilter
    {
        private NoiseSettings.SimpleNoiseSettings settings;
        private Noise noise = new Noise();

        public SimpleNoiseFilter(NoiseSettings.SimpleNoiseSettings settings)
        {
            this.settings = settings;
        }

        public float Evaluate(Vector3 point)
        {
            float noiseValue = 0;
            float frequency = settings.baseRoughness;
            float amplitude = 1;

            for (int i = 0; i < settings.numLayers; i++)
            {
                frequency *= settings.frequency;
                amplitude *= settings.amplitude;

                float v = noise.Evaluate(point * frequency + settings.centre);
                noiseValue += (v + 1) * .5f * amplitude;

            }

            noiseValue = noiseValue - settings.minValue;
            return noiseValue * settings.strength;
        }
    }
}