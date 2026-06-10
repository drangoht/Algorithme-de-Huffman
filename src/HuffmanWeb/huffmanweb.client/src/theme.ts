import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#00D4FF',
      light: '#40E0FF',
      dark: '#009FCC',
      contrastText: '#060B16',
    },
    secondary: {
      main: '#818CF8',
      light: '#A5B4FC',
      dark: '#6366F1',
      contrastText: '#060B16',
    },
    success: { main: '#34D399' },
    warning: { main: '#F59E0B' },
    error: { main: '#F87171' },
    background: {
      default: '#060B16',
      paper: '#0A1628',
    },
    text: {
      primary: '#E2E8F0',
      secondary: '#94A3B8',
    },
    divider: 'rgba(0, 212, 255, 0.12)',
  },
  typography: {
    fontFamily: '"Inter", -apple-system, BlinkMacSystemFont, sans-serif',
    h1: { fontFamily: '"Orbitron", sans-serif' },
    h2: { fontFamily: '"Orbitron", sans-serif' },
    h3: { fontFamily: '"Orbitron", sans-serif' },
  },
  shape: { borderRadius: 8 },
  components: {
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          scrollbarWidth: 'thin',
          scrollbarColor: 'rgba(0,212,255,0.3) #060B16',
          '&::-webkit-scrollbar': { width: 6 },
          '&::-webkit-scrollbar-track': { background: '#060B16' },
          '&::-webkit-scrollbar-thumb': {
            background: 'rgba(0,212,255,0.3)',
            borderRadius: 3,
          },
        },
      },
    },
    MuiPaper: {
      styleOverrides: {
        root: {
          backgroundImage: 'none',
          backgroundColor: '#0A1628',
          border: '1px solid rgba(0, 212, 255, 0.12)',
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          textTransform: 'none',
          borderRadius: 6,
          fontWeight: 500,
        },
      },
    },
    MuiAccordion: {
      styleOverrides: {
        root: {
          backgroundColor: 'rgba(10, 22, 40, 0.85)',
          border: '1px solid rgba(0, 212, 255, 0.12)',
          borderRadius: '8px !important',
          marginBottom: '12px',
          boxShadow: 'none',
          '&:before': { display: 'none' },
          '&.Mui-expanded': { margin: '0 0 12px 0' },
          '&:hover': { borderColor: 'rgba(0, 212, 255, 0.25)' },
          transition: 'border-color 0.2s ease',
        },
      },
    },
    MuiAccordionSummary: {
      styleOverrides: {
        root: {
          color: '#00D4FF',
          fontFamily: '"Orbitron", sans-serif',
          fontSize: '0.75rem',
          letterSpacing: '1.5px',
          textTransform: 'uppercase',
          minHeight: 48,
          '&.Mui-expanded': {
            minHeight: 48,
            borderBottom: '1px solid rgba(0, 212, 255, 0.12)',
          },
        },
        content: { margin: '12px 0', '&.Mui-expanded': { margin: '12px 0' } },
        expandIconWrapper: { color: '#00D4FF' },
      },
    },
    MuiAccordionDetails: {
      styleOverrides: {
        root: { padding: '16px', backgroundColor: 'transparent' },
      },
    },
    MuiDialog: {
      styleOverrides: {
        paper: {
          backgroundColor: '#0A1628',
          border: '1px solid rgba(0, 212, 255, 0.25)',
          borderRadius: 12,
          boxShadow: '0 0 40px rgba(0, 212, 255, 0.12), 0 25px 50px rgba(0,0,0,0.5)',
        },
      },
    },
    MuiDialogTitle: {
      styleOverrides: {
        root: {
          fontFamily: '"Orbitron", sans-serif',
          color: '#00D4FF',
          borderBottom: '1px solid rgba(0, 212, 255, 0.12)',
          fontSize: '0.8rem',
          letterSpacing: '2px',
          textTransform: 'uppercase',
          padding: '16px 24px',
        },
      },
    },
    MuiDialogContent: {
      styleOverrides: {
        root: { padding: '20px 24px', color: '#E2E8F0' },
      },
    },
    MuiTab: {
      styleOverrides: {
        root: {
          textTransform: 'none',
          fontFamily: '"Inter", sans-serif',
          fontWeight: 500,
          fontSize: '0.9rem',
          letterSpacing: '0.3px',
          color: '#64748B',
          padding: '10px 24px',
          '&.Mui-selected': { color: '#00D4FF' },
          '&:hover': { color: '#94A3B8' },
          transition: 'color 0.2s ease',
        },
      },
    },
    MuiTabs: {
      styleOverrides: {
        root: { borderBottom: '1px solid rgba(0, 212, 255, 0.10)' },
        indicator: {
          backgroundColor: '#00D4FF',
          boxShadow: '0 0 10px rgba(0, 212, 255, 0.6)',
          height: 2,
        },
      },
    },
    MuiTooltip: {
      styleOverrides: {
        tooltip: {
          backgroundColor: '#0F2040',
          border: '1px solid rgba(0, 212, 255, 0.25)',
          color: '#E2E8F0',
          fontSize: '0.75rem',
          borderRadius: 6,
        },
      },
    },
    MuiIconButton: {
      styleOverrides: {
        root: {
          color: '#64748B',
          '&:hover': { color: '#00D4FF', backgroundColor: 'rgba(0,212,255,0.08)' },
          transition: 'color 0.2s ease, background-color 0.2s ease',
        },
      },
    },
    MuiLinearProgress: {
      styleOverrides: {
        root: {
          backgroundColor: 'rgba(0,212,255,0.10)',
          borderRadius: 4,
          height: 6,
        },
        bar: {
          background: 'linear-gradient(90deg, #00D4FF, #818CF8)',
          borderRadius: 4,
        },
      },
    },
  },
});

export default theme;
