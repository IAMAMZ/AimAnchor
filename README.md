# AimAnchor

## Introduction

AimAnchor is a web-based application developed using ASP.NET Core MVC, serving as a practical tool to manage and track goals and habits through a structured hierarchy. This project was designed to explore the practical implementation of hierarchical data management and user interaction in a web development context.

## Purpose and Functionality

The application primarily assists users in establishing and tracking their goals on a hierarchical basis: yearly objectives, broken down into smaller sub-goals, and further into daily tasks or habits. Here’s a brief on its core functionalities:

### Hierarchical Goal Setting

- **GoalSets**: Define overarching objectives or aspirations, typically on a yearly basis.
- **Goals**: Break down GoalSets into smaller, actionable goals or tasks.

### Daily Progress Tracking and Reflection

- **Daily GoalSet Feedback**: Users document their daily activities, successes, and areas of improvement.

## Technology Stack

- **Back-End**: ASP.NET Core MVC
- **ORM**: Entity Framework
- **Front-End**: Bootstrap, JavaScript, and jQuery
- **Database**: SQL Server

## Models

1. **GoalSet**: Encompasses broad objectives, containing a title, description, and timeframe.
2. **Goal**: Nested within a GoalSet, it details specific tasks or objectives needed to realize the parent goal.
3. **Daily GoalSet Feedback**: Enables users to log and reflect on their daily progress, associated with specific GoalSets.

## Challenges and Learning Outcomes

### Managing Hierarchical Data

Implementing a structure where data is interrelated hierarchically, and ensuring data integrity and ease of navigation was a pivotal aspect of this project.

### User Interaction and Experience

Ensuring that the UI/UX allows for intuitive navigation, goal-setting, and reflection while managing underlying complexities in data relationships.

## Future Enhancements

- Implementing an analytics dashboard, providing users with insights into their progress and areas needing attention.
- Introducing collaborative goal-setting and progress tracking, where users can co-create and manage GoalSets.

## License

AimAnchor is released under the MIT License. Check out the `LICENSE` file for more details.

## Contact Information

- **Developer**: Your Name
- **Email**: [YourEmail@example.com](mailto:youremail@example.com)

For more details, please visit the project repository [here](https://github.com/YourGitHubUsername/AimAnchor).
