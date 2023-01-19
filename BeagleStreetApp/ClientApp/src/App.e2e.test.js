import puppeteer from 'puppeteer';

describe('App.js', () => {
    let browser;
    let page;

    beforeAll(async () => {
        browser = await puppeteer.launch();
        page = await browser.newPage();
    });

    it('displays the weather for the default location', async () => {
        await page.goto('https://localhost:44418');
        await page.waitForSelector('#location');
        const text = await page.$eval('#location', (e) => e.textContent);
        expect(text).toContain('London');
    });

    it('updates to display the weather for the given location', async () => {
        await page.goto('https://localhost:44418');
        await page.waitForSelector('#location');
        await page.click('#locationBtn');
        await page.type('#locationInput', 'Leicester');
        await page.click('#changeLocationBtn');
        await page.waitForFunction('document.getElementById("location").textContent != "London"');
        const text = await page.$eval('#location', (e) => e.textContent);
        expect(text).toContain('Leicester');
    });

    it('displays an error message for an invalid location', async () => {
        await page.goto('https://localhost:44418');
        await page.waitForSelector('#location');
        await page.click('#locationBtn');
        await page.type('#locationBtn', 'fakelocation');
        await page.click('#changeLocationBtn');
        await page.waitForSelector('.invalid-feedback', { visible: true });
        const text = await page.$eval('.invalid-feedback', (e) => e.textContent);
        expect(text).toContain('Invalid location');
    });

    afterAll(() => browser.close());
});