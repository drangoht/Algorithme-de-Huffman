import { createTheme } from '@mui/material/styles';

const FONT = '"JetBrains Mono", "Fira Code", Consolas, monospace';
const GREEN = '#22C55E';
const GREEN_BRIGHT = '#4ADE80';
const BG = '#080808';
const BG_SURFACE = '#0D0D0D';
const TEXT = '#86EFAC';
const BORDER = 'rgba(34, 197, 94, 0.20)';
const BORDER_BRIGHT = 'rgba(34, 197, 94, 0.45)';

const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: GREEN,
      light: GREEN_BRIGHT,
      dark: '#16A34A',
      contrastText: '#000',
    },
    secondary: {
      main: '#16A34A',
      light: GREEN,
      dark: '#166534',
      contrastText: '#000',
    },
    success:  { main: GREEN },
    warning:  { main: '#F59E0B' },
    error:    { main: '#F87171' },
    background: {
      default: '#000000',
      paper: BG_SURFACE,
    },
    text: {
      primary: TEXT,
      secondary: 'rgba(134,239,172,0.55)',
    },
    action: {
      hover: 'rgba(34,197,94,0.07)',
      selected: 'rgba(34,197,94,0.12)',
      focus: 'rgba(34,197,94,0.10)',
      disabled: 'rgba(134,239,172,0.26)',
      disabledBackground: 'rgba(34,197,94,0.08)',
    },
    divider: BORDER,
  },
  typography: {
    fontFamily: FONT,
    allVariants: { fontFamily: FONT },
  },
  shape: { borderRadius: 0 },
  components: {
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          scrollbarWidth: 'thin',
          scrollbarColor: `#16A34A ${BG}`,
        },
      },
    },
    MuiPaper: {
      styleOverrides: {
        root: {
          backgroundImage: 'none',
          backgroundColor: BG_SURFACE,
          border: `1px solid ${BORDER}`,
          borderRadius: 0,
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          textTransform: 'uppercase',
          borderRadius: 0,
          fontFamily: FONT,
          fontSize: '0.72rem',
          fontWeight: 600,
          letterSpacing: '2px',
        },
        contained: {
          background: 'transparent',
          color: GREEN,
          border: `1px solid ${BORDER_BRIGHT}`,
          boxShadow: 'none',
          '&:hover': {
            background: 'rgba(34,197,94,0.08)',
            boxShadow: '0 0 8px rgba(34,197,94,0.3)',
            border: `1px solid ${GREEN}`,
          },
          '&:disabled': {
            color: 'rgba(134,239,172,0.2)',
            border: `1px solid rgba(34,197,94,0.10)`,
            background: 'transparent',
          },
        },
        outlined: {
          borderColor: BORDER,
          color: TEXT,
          '&:hover': {
            borderColor: GREEN,
            color: GREEN_BRIGHT,
            background: 'rgba(34,197,94,0.06)',
          },
        },
        text: {
          color: TEXT,
          '&:hover': { color: GREEN, background: 'rgba(34,197,94,0.06)' },
        },
      },
    },
    MuiIconButton: {
      styleOverrides: {
        root: {
          color: 'rgba(134,239,172,0.4)',
          borderRadius: 0,
          '&:hover': {
            color: GREEN,
            background: 'rgba(34,197,94,0.08)',
          },
        },
      },
    },
    MuiAccordion: {
      styleOverrides: {
        root: {
          backgroundColor: BG,
          border: `1px solid ${BORDER}`,
          borderLeft: `2px solid #16A34A`,
          borderRadius: '0 !important',
          marginBottom: '10px',
          boxShadow: 'none',
          '&:before': { display: 'none' },
          '&.Mui-expanded': { margin: '0 0 10px 0' },
          '&:hover': { borderColor: GREEN },
          transition: 'border-color 0.15s ease',
        },
      },
    },
    MuiAccordionSummary: {
      styleOverrides: {
        root: {
          color: GREEN,
          fontFamily: FONT,
          fontSize: '0.72rem',
          fontWeight: 600,
          letterSpacing: '2px',
          textTransform: 'uppercase',
          minHeight: 40,
          '&.Mui-expanded': {
            minHeight: 40,
            borderBottom: `1px solid ${BORDER}`,
          },
          '&::before': {
            content: '"// "',
            color: 'rgba(34,197,94,0.4)',
            fontWeight: 300,
          },
        },
        content: { margin: '10px 0', '&.Mui-expanded': { margin: '10px 0' } },
        expandIconWrapper: { color: 'rgba(34,197,94,0.5)' },
      },
    },
    MuiAccordionDetails: {
      styleOverrides: {
        root: { padding: '14px 16px', backgroundColor: 'transparent' },
      },
    },
    MuiDialog: {
      styleOverrides: {
        paper: {
          backgroundColor: BG_SURFACE,
          border: `1px solid ${BORDER_BRIGHT}`,
          borderRadius: 0,
          boxShadow: `0 0 30px rgba(34,197,94,0.10), 0 20px 40px rgba(0,0,0,0.8)`,
        },
      },
    },
    MuiDialogTitle: {
      styleOverrides: {
        root: {
          fontFamily: FONT,
          color: GREEN,
          borderBottom: `1px solid ${BORDER}`,
          fontSize: '0.72rem',
          letterSpacing: '3px',
          textTransform: 'uppercase',
          padding: '12px 20px',
          '&::before': { content: '"// "', opacity: 0.5 },
        },
      },
    },
    MuiDialogContent: {
      styleOverrides: {
        root: { padding: '16px 20px', color: TEXT, fontFamily: FONT },
      },
    },
    MuiTab: {
      styleOverrides: {
        root: {
          textTransform: 'uppercase',
          fontFamily: FONT,
          fontWeight: 500,
          fontSize: '0.72rem',
          letterSpacing: '2px',
          color: 'rgba(134,239,172,0.35)',
          padding: '10px 20px',
          borderRadius: 0,
          '&.Mui-selected': {
            color: GREEN,
            textShadow: '0 0 8px rgba(34,197,94,0.5)',
          },
          '&:hover': {
            color: 'rgba(134,239,172,0.65)',
            backgroundColor: 'rgba(34,197,94,0.06)',
          },
          '& .MuiTouchRipple-child': {
            backgroundColor: 'rgba(34,197,94,0.25)',
          },
        },
      },
    },
    MuiTabs: {
      styleOverrides: {
        root: { borderBottom: `1px solid ${BORDER}`, minHeight: 40 },
        indicator: {
          backgroundColor: GREEN,
          boxShadow: '0 0 8px rgba(34,197,94,0.6)',
          height: 1,
        },
      },
    },
    MuiTooltip: {
      styleOverrides: {
        tooltip: {
          backgroundColor: '#111',
          border: `1px solid ${BORDER}`,
          color: TEXT,
          fontFamily: FONT,
          fontSize: '0.72rem',
          borderRadius: 0,
        },
      },
    },
    MuiLinearProgress: {
      styleOverrides: {
        root: {
          backgroundColor: 'rgba(34,197,94,0.08)',
          borderRadius: 0,
          height: 3,
        },
        bar: {
          background: `linear-gradient(90deg, #16A34A, ${GREEN})`,
          borderRadius: 0,
        },
      },
    },
    MuiAlert: {
      styleOverrides: {
        root: {
          fontFamily: FONT,
          fontSize: '0.78rem',
          borderRadius: 0,
        },
        standardError: {
          backgroundColor: 'rgba(248,113,113,0.06)',
          border: '1px solid rgba(248,113,113,0.3)',
          color: '#FECACA',
          borderLeft: '2px solid #F87171',
        },
        standardWarning: {
          backgroundColor: 'rgba(245,158,11,0.06)',
          border: '1px solid rgba(245,158,11,0.3)',
          color: '#FDE68A',
          borderLeft: '2px solid #F59E0B',
        },
        icon: { opacity: 0.8 },
      },
    },
    MuiCircularProgress: {
      styleOverrides: {
        root: { color: GREEN },
      },
    },
  },
});

export default theme;
