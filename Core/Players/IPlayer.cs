namespace Core.Players
{
    public interface IPlayer
    {
        void Play(string path);
        void Pause();
        void Stop();
    }
}