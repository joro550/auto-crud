# Welcome to Tilt!
#   To get you started as quickly as possible, we have created a
#   starter Tiltfile for you.
#
#   Uncomment, modify, and delete any commands as needed for your
#   project's configuration.


# Output diagnostic messages
#   You can print log messages, warnings, and fatal errors, which will
#   appear in the (Tiltfile) resource in the web UI. Tiltfiles support
#   multiline strings and common string operations such as formatting.
#
#   More info: https://docs.tilt.dev/api.html#api.warn
print("""
-----------------------------------------------------------------
✨ Hello Tilt! This appears in the (Tiltfile) pane whenever Tilt
   evaluates this file.
-----------------------------------------------------------------
""".strip())

print('ℹ️ Open {tiltfile_path} in your favorite editor to get started.'.format(
    tiltfile_path=config.main_path))


local_resource(
    'tests',
    'dotnet test ./AutoCrud.Api.Tests/AutoCrud.Api.Tests.csproj -o out/tests',
    deps=[
        './AutoCrud.Api',
        './AutoCrud.Api.Tests',
        './AutoCrud.Api.Logic',
    ],
    ignore=[
        
        './AutoCrud.Api/bin',
        './AutoCrud.Api/obj',
        './AutoCrud.Api.Tests/bin',
        './AutoCrud.Api.Tests/obj',
        './AutoCrud.Api.Logic/bin',
        './AutoCrud.Api.Logic/obj',
    ]
)