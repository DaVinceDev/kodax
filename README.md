# Kodax - A CLI .NET WEBAPI PROJECT ARCHITECT

Kodax is a cli tool with the objective to speed up development (for now only) .NET WEBAPI Projects. This is a tool that helps me a lot
when it comes to start a new API in C# since it takes up to 10 mins to have a solid base on a project that could take like 2 days to even
have a decent base.


## Inspiration

Kodax was inspired by ng (The angular cli tool), as well for the architecture(feature-based). I like the way my frontend is organized,
with all features having its own space so I decided to take that inspiration and project it to make Kodax.


### Why the name Kodax?

Sounds cool and catchy.

## Instalation

The instalation process is very simple:

1º You have two choices, either Windows or Linux, go to the release page and choose based on your target arch

For Linux:

```bash
chmod +x kodax          # Make kodax executable

mv kodax ~/.local/bin/  # Move it to a 'global path'. Make sure it exists tho

export PATH="~/.local/bin:$PATH" # Export the path

kodax # Start using it
```

For Windows:

Download the .exe
Move to a dot directory like (:C/.local/bin)
Add that directory to your path
Maybe reboot and then enjoy it 

### About the templates

For the templates, you need to download the source code and copy the templates folder to this path ``` .config/kodax/ ```, you have to create it(duh).

After that run ``` kodax setup ``` to make sure everything is set.

# About contributions

Contribuitions are accepted but major decisions will be decided by me (the creator of the tool). But feel free to make PR's, issue and
even suggest some ideas that could make Kodax a lot cooler.

## The future of Kodax

I imagine Kodax as THE project architect for .NET applications(and maybe even out of scope of C#), being able to detect the nature of
the project, having custom architecture choices and more without any bloat(I hate slow tools from the heart).
