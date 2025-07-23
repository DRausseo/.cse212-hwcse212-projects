/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO). When GetNextPerson is called, the next person is dequeued and 
/// returned. If the person has remaining turns (or infinite turns), they are added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns--;
        }

        // Re-enqueue if the person has more turns, or infinite turns (turns <= 0)
        if (person.Turns != 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }
}
