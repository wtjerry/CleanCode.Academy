# Getting started

## using the api manually
see http_calls.http file.


## docker
to build an image:

```docker build -t example_project_structure_cc .```

and then to create and run a container:

```docker run --rm localhost/example_project_structure_cc```

or if you're having trouble in WSL maybe:

```podman run --rm --publish=5000 --events-backend=file localhost/example_project_structure_cc```