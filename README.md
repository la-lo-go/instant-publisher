# InstantPublisher

XrmToolBox plugin that monitors local files and instantly publishes Web Resources and DLLs to Dataverse on change.

## Features

### Web Resource Publishing

- **Map manually**: Browse a local file and pick the corresponding Dataverse web resource from a tree view organized by path.
- **Auto map**: Select a local file and the plugin automatically finds the matching web resource in Dataverse by file name. If no match is found, it offers to fall back to manual selection.

### Plugin Assembly Publishing

- **Automatic assembly resolution**: On first publish, the plugin queries Dataverse for a `pluginassembly` record matching the DLL's name, public key token, and major.minor version. The match is cached for subsequent publishes.

### Settings Persistence

The plugin saves and restores the monitored items list automatically per Dataverse connection.

### Export / Import

- **Export**: Save the current list of monitored files (paths, web resource IDs, names, auto flags) to a JSON file.
- **Import**: Load a previously exported JSON file to restore a monitoring configuration. Duplicates are skipped.

Useful for sharing setups between team members or restoring a configuration after reinstalling.

### Keyboard Shortcuts

| Shortcut       | Action                        |
|----------------|-------------------------------|
| Ctrl+Shift+P   | Publish all modified items    |
| Ctrl+E         | Export configuration to JSON  |
| Ctrl+I         | Import configuration from JSON|
