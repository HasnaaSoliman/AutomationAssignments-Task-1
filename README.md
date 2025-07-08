# AutomationAssignments
# Selenium Basic Methods and Web Elements (C#)
This repository demonstrates basic browser automation and element interaction using **Selenium WebDriver with C#**.

## Project Structure

The project consists of two main tasks:

---

## Task 1: Selenium Basic Methods

### Description:
This task covers core browser operations such as navigation, window management, and retrieving page metadata.

### Steps Performed:
1. Open Chrome browser and navigate to `https://example.com`.
2. Print:
   - Current URL
   - Page title
   - Page HTML source
3. Print the unique window handle (browser session ID).
4. Navigate to `https://www.selenium.dev`.
5. Perform browser navigation actions:
   - Go back
   - Go forward
   - Refresh the page
6. Print current browser window's:
   - Size
   - Position
7. Resize the browser window to:
   - Width: 1024  
   - Height: 768
8. Move the browser window to position:
   - X: 200  
   - Y: 150
9. Maximize the browser window, then switch to full screen.
10. Close the current tab.
11. Re-launch the browser, navigate to a new site, and quit the entire session.

---

## Task 2: Web Elements and Locators

### Description:
This task demonstrates how to locate and interact with web elements using different Selenium locator strategies.

### URL:
`https://www.facebook.com/r.php?entry_point=login`

### Locators Used:
- **By ID**
- **By Name**
- **By ClassName**
- **By TagName**
- **By XPath**
- **By CSS Selector**

### Actions Performed:
- Locate the first name, last name, email, password, and birthdate fields.
- Fill in test data using each of the locator strategies above.
- Print element attributes (e.g., `placeholder` from TagName).
