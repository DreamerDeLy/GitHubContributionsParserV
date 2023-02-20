# GitHub Contributions Parser V

*Advanced tool for analyzing GitHub contributions statistics*

![Screenshot](Screenshot1.png)

# How it works?

This program parse the user page on GitHub and gets data from calendar visualization of your contributions. 

Each day in this calendar is implemented as a `rect` HTML element which contains all usefull data:

```html
<rect width="11" height="11" x="-20" y="45" class="ContributionCalendar-day" data-date="2022-11-02" data-level="4" rx="2" ry="2">9 contributions on Wednesday, November 2, 2022</rect>
```

## Features 
* Export to CSV
* Displaying graphs 
  * Data by months
  * Data by weekdays 
  * Days with and without commits
* Displaying some statistics 
  * Longest streak
  * Day with max contributions
  * Commits per day ratio
  * Forecast

