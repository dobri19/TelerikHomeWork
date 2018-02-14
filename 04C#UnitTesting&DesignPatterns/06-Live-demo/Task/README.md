## Task: Refactor Olympics

### Create CommandFactory

Use it for creating all the commands needed by the Engine

```
public class CommandFactory : ICommandFactory ...
```

```
public CommandFactory(IComponentContext container)
{
    this.container = container;
}
```

### Move the parameters for creating command outside the constructor

CommandParameters must be passed in the Execute method in order for the command to work.

```
public ListOlympiansCommand(IOlympicCommittee committee, IOlympicsFactory factory, IList<string> commandParameters)
```


### Make a decorator for ListOlympiansCommand

It must log a message every time the command is executed. Use the interface below.

[Decorator](https://sourcemaking.com/design_patterns/decorator) 

```
public interface ICommand
{
    string Execute();
}
```

### Use the ConfigurationManager with app.config

```
var isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

if (isTest)
{
    builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians");

}
else
{

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
-- [01.02.2018 13:45:23] Processed Command --
####################
```
