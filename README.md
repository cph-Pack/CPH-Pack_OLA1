# CPH-Pack_OLA1
By Patrick, Albert, Kevin & Caroline

# Test Strategy Design
# Scope
The testing will be performed on a simple to-do list application which includes the following functionalities:
- Adding, updating, deleting, and marking tasks as completed
- Categorizing tasks into different lists
- Setting deadlines for tasks
- Storing the to-do list in a file

# Test Goals
The key functionalities can be found in the ‘Scope’ section. We aim to test all functionalities.

Our goals for the testing include:
- Validating that the functionalities of the to-do list application behave according to the specification
- Confirming that different components and the file system are interacting correctly

# Sprint Timelines
The plan is that this is a proof-of-concept sprint, so we will have a single sprint with a duration of a single week.  
For the first part of the sprint, we will focus on creating our test strategy, then we will start testing.

# Test Approach
We plan on:
- Manually running tests before committing.
We will be following these style guides:
- Using arrange-act-assert style in each test. This means no global settings.
- For naming, we use “Unit of Work, State under Test, Expected Behavior” (see chapter 7, page 87).  
- Duplication is okay if it increases readability.  

# Testing Types

### Unit Tests
- **Where to use:** For each of the components making up the core functionalities.
- **Dependencies:** Minimal. We will likely use test doubles in some tests to isolate the component during the tests.
- **Criticality:** Highest priority in this specific test scenario as we want to ensure that the basic functionality functions as expected.

### Integration Tests
- **Where to use:** In areas where multiple components interact and when integrating with the file system.
- **Dependencies:** The integration test will require access to the file system.
- **Criticality:** Second-highest priority as we want to make sure that the components interact with each other as expected and that files are stored properly.

### Specification-based Test
- **Where to use:** Where there will be some decision-making logic that can result in different outcomes based on different inputs.
- **Dependencies:** Depends on the entire workflow to be implemented first.
- **Criticality:** The lowest priority for this specific test scenario as the scope is quite small.

### Mutation Testing
- **Where to use:** After developing the test suite and across all critical components of the application.
- **Dependencies:** We will be using a testing tool for the mutation testing, and it will likely include external dependencies as well.
- **Criticality:** Third-highest priority as we are interested in measuring the robustness of the test suite.

# Roles and Responsibilities

### What are the different roles?
The roles we’ll use for this project will be as follows: **Test Managers/Testers** and **Developers**.
- **Testers and Test Managers** are responsible for performing the actual test cases and making sure that the software complies with the quality requirements. They will also be responsible for the planning of the test cases.
- **Developers** will be responsible for correcting the mistakes within the software that the testers might find during their tests, and they will work closely with the testers.

# Testing Tools
The testing will be made with:
- **xUnit** for unit testing
- **Stryker** for mutation testing

# Reflection and Discussion
## Verification vs. Validation
Verification is about what we as developers want to accomplish with the applications specification requirements during development. To follow these specifications, Code reviews would be a great way of keeping up the quality of the code.

Validation isn’t about how we got to where we should be, but about what we have developed and everything within the system is working as expected. This is done at the end of the module or application and makes sure that the stakeholder is handed the product they expect to have delivered. The tests associated within validation are typically high level tests such as regression test, user testing, performance testing etc.

## Software Quality Reflection

## Discussion on Test Categories
Martin Fowler describes several test categories on his website. 
1. Broad Stack Tests, also known as End-to-End tests or full-stack tests, are tests that evaluate most of the parts of an application. The tests often simulate real-world usage across systems, and can be done by manipulating the UI with tools like fx. Selenium. They are often harder to maintain and slower to run than component tests.
2. Business-Facing Tests help communicate with non-technical members of development, and often act as acceptance criteria. Business-facing tests are often implemented as broad stack tests, and they can include story tests and user journey tests.
3. Component Tests focus on a specific part of the system, while ignoring other parts. Component tests are usually easier to write and maintain and faster to run than broad stack tests.
4. Contract Tests ensure interactions with external services are consistent, and are useful when otherwise using test doubles for the testing as it ensures the accuracy of the test doubles. The tests depend on the changes to the external services, and do not need to be part of the regular deployment pipeline.
5. Integration Tests have various definitions, but the tests verify that different modules of the system work together. Fowler arranges them from narrow to broad in scope. The narrow integration tests have a scope similar to unit tests and only exercise the portion of the code that specifically talks to another separate module. In contrast, broad tests all code paths between the different modules, not just the code responsible for interaction between. He also argues that in some cases it may mean sociable unit tests. 
6. Story Tests are business-facing tests tied to a specific user story. The tests can be added to the regression suite to ensure the system’s behaviour aligns with the requirements.
7. Subcutaneous Tests target layers just below the user interface for functional testing.
8. Threshold Tests monitor performance or other metrics, ensuring the system stays within acceptable limits.
9. Unit Tests also have various definitions, but they focus on small parts of code, usually written by developers, and are designed to be fast and run frequently. Fowler differentiates between sociable and solitary unit tests. For sociable unit tests there will be some dependency between more parts than just fx. a single class. Some may want to mock this dependency, Fowler calls this a mockist style, and they will write solitary unit tests, as they isolate the unit. But what a unit is is also debated.
10. User Journey tests simulate a typical user's interaction with the system, following a path to achieve a goal. These broad-stack tests focus on key user flows, often the happy path, and are used to validate overall system integration.

We have added component tests in the form of unit tests and broad stack tests in the form of integration tests. We have mostly stuck to writing solitary unit tests.

