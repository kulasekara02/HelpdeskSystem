# Contributing to Helpdesk System

Thank you for your interest in contributing to the Helpdesk System project! 🎉

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check existing issues. When creating a bug report, include:

- **Clear title and description**
- **Steps to reproduce** the issue
- **Expected behavior** vs **actual behavior**
- **Screenshots** if applicable
- **Environment details** (OS, .NET version, browser)

### Suggesting Enhancements

Enhancement suggestions are welcome! Please provide:

- **Clear description** of the feature
- **Use case** explaining why it would be useful
- **Possible implementation** approach (optional)

### Pull Requests

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Make your changes
4. Commit with clear messages (`git commit -m 'Add amazing feature'`)
5. Push to the branch (`git push origin feature/AmazingFeature`)
6. Open a Pull Request

## Development Setup

```bash
# Clone your fork
git clone https://github.com/YOUR-USERNAME/HelpdeskSystem.git
cd HelpdeskSystem

# Add upstream remote
git remote add upstream https://github.com/kulasekara02/HelpdeskSystem.git

# Install dependencies
dotnet restore

# Run the application
cd src/HelpdeskSystem.Web
dotnet run
```

## Code Style

- Follow [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and concise
- Write unit tests for new features

## Project Structure

```
src/
├── Domain/         # Entities, Enums (no dependencies)
├── Application/    # Services, DTOs, Interfaces
├── Infrastructure/ # Data access, EF Core
└── Web/           # Blazor UI, API endpoints
```

## Commit Message Guidelines

- Use present tense ("Add feature" not "Added feature")
- Use imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit first line to 72 characters
- Reference issues and PRs after first line

Example:
```
Add user profile edit functionality

- Create edit profile component
- Add validation for email and phone
- Update user service with edit method

Closes #123
```

## Testing

```bash
# Run tests (when available)
dotnet test
```

## Questions?

Feel free to open an issue with the `question` label.

## License

By contributing, you agree that your contributions will be licensed under the MIT License.
