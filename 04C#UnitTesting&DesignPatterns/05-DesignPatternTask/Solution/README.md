## Task: Implement Decorator pattern in OlympicGames project

### LoggerCommandProcessor

You must create a decorated CommandProcessor which implements ICommandParser. It should log on the console each time a command has been processed and the time when this happened.

[Decorator](https://sourcemaking.com/design_patterns/decorator) 

```
using System.Collections.Generic;

namespace OlympicGames.Core.Contracts
{
    public interface ICommandProcessor 
    {
        ICollection<ICommand> Commands { get; }

        void ProcessSingleCommand(ICommand command);
    }
}
```

### Example

The last line should be added to the output

```
createboxer Wladimir Klitschko Ukraine heavyweight 64 5
Created Boxer
BOXER: Wladimir Klitschko from Ukraine
Category: Heavyweight
Wins: 64
Losses: 5
####################
-- [01.02.2018 13:45:23] Processed Command --
```
