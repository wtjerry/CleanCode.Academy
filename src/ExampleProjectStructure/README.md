# Getting started

## using the api manually
see http_calls.http file.


## docker
to build an image:

```docker build -t example_project_structure_cc .```

and then to create and run a container:

```docker run --rm -p=8080:8080 localhost/example_project_structure_cc```

or if you're having trouble in WSL maybe:

```podman run --rm --publish=5000 --events-backend=file localhost/example_project_structure_cc```

## devcontainer
follow your IDEs documentation to setup & start a devcontainer (e.g. https://www.jetbrains.com/help/rider/Prerequisites_for_dev_containers.html)

gotchas:
- by default a ```dotnet run``` starts the app on port 8080, ```http_calls.http``` expects port 5000. You might need to change that.