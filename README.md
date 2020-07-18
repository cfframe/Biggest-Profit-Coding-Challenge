# Computershare-Coding-Challenge
Computershare Coding Challenge

Console application - download, build and run.

COPIED FROM SUPPLIED CHALLENGE SHEET:

# Description
You are going to make it big by playing the stock market – “buy low, sell high” you scream as you sit down at your computer. You’ve heard good things about this company Computershare - so you start investigating its historic share prices. You’re going to need to time your trades so that you make the biggest gain possible! But there’s a catch, as you’re new to the game, your broker will only allow you one trade.

So, you look back at a list of market-opening prices for Computershare stock. You are not into this risky day-trading approach, so are looking at the opening price each day of the last month.

You decide to put a program together (using industry best-practice standards of course!) using your favorite language, to help you work out what the single best trade you could have made that month would be, to maximize gain. 

Remember - buy low, sell high. And before you ask… unfortunately your DeLorean won’t start, so you can't sell before you buy.

# Input Description
Your program will be provided with a list of Computershare’s market-opening stock prices from the beginning of each trading day of the last month. It will be formatted as a comma separated list of two decimal floats (pounds and pence), listed in chronological order from day 1 through to day 30 of the month.

Example:

19.15,18.30,18.88,17.93,15.95,19.03,19.00 etc..

# Output Description
Your program should provide the buy day and sell day – so two days of the month and their opening stock prices. So, in chronological order showing when you should buy, and sell, again separated by a comma.

To confirm - the format being buyDayOfMonth(price),sellDayOfMonth(price)

Example:

5(15.95),6(19.03)

# Sample Data Sets
Set 1
18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03

Set 2
22.74,22.27,20.61,26.15,21.68,21.51,19.66,24.11,20.63,20.96,26.56,26.67,26.02,27.20,19.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61
